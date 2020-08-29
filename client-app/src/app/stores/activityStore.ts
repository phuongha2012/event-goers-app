import { observable, action, computed, runInAction } from 'mobx';
import { SyntheticEvent } from 'react';
import { IActivity } from '../models/activity';
import agent from '../api/agent';
import { history } from '../..';
import { toast } from 'react-toastify';
import { RootStore } from './rootStore';
import { setActivityProps } from '../common/util/util';

export default class ActivityStore {
    rootStore: RootStore;
    constructor(rootStore: RootStore) {
        this.rootStore = rootStore;
    }

    @observable activityRegistry = new Map();
    @observable activity: IActivity | null = null;
    @observable loadingInitial = false;
    @observable submitting = false;
    @observable target = '';

    @computed get activitiesByDate() {
        // return Array.from(this.activityRegistry.values()).sort((a, b) => Date.parse(a.date) - Date.parse(b.date));
        return this.groupActivitiesByDate(Array.from(this.activityRegistry.values()))
    }

    groupActivitiesByDate(activities: IActivity[]) {
        const sortedActivites = activities.sort(
            (a, b) => a.date.getTime() - b.date.getTime()
        )
        return Object.entries(sortedActivites.reduce((activities, activity) => {
            const date = activity.date.toISOString().split('T')[0];
            activities[date] = activities[date] ? [...activities[date], activity] : [activity];
            return activities;
        }, {} as {[key: string]: IActivity[]}));
    } 

    @action loadActivities = async () => {
        this.loadingInitial = true;
        try {
            const activities = await agent.Activities.list();
            runInAction('loading activities', () => {
                activities.forEach((activity) => {
                    setActivityProps(activity, this.rootStore.userStore.user!)
                    this.activityRegistry.set(activity.id, activity);
                    });
                    this.loadingInitial = false;
            })
        } catch (error) {
            console.log(error);
            runInAction('loading activities error', () => {
                this.loadingInitial = false;
            })
        }
    }

    @action selectActivity = (id: string) => {
        this.activity = this.activityRegistry.get(id);
    }

    @action loadActivity = async (id: string) => {
        let activity = this.getActivity(id);
        if (activity) {
            this.activity = activity;
            return activity;
        } else {
            this.loadingInitial = true;
            try {
                activity = await agent.Activities.details(id);
                runInAction(() => {
                    setActivityProps(activity, this.rootStore.userStore.user!)
                    this.activity = activity;
                    this.activityRegistry.set(activity.id, activity);
                    this.loadingInitial = false;
                })
                return activity;
            } catch (error) {
                runInAction('get activity error', () => {
                    this.submitting = false;
                }) 
                console.log(error);
            }
        }
    }

    @action clearActivity = () => {
        this.activity = null;
    }

    getActivity = (id: string) => {
        return this.activityRegistry.get(id);
    }

    @action createActivity = async (activity: IActivity) => {
        this.submitting = true;
        try {
            await agent.Activities.create(activity);
            runInAction('creating activity',() => {
                this.activityRegistry.set(activity.id, activity);
                this.submitting = false;
            })
            history.push(`/activities/${activity.id}`)
        } catch (error) {
            toast.error('Problem submitting data');
            runInAction('create activity error', () => {
                this.submitting = false;
            })  
        }
    }

    @action editActivity = async (activity: IActivity) => {
        this.submitting = true;
        try {
            await agent.Activities.update(activity);
            runInAction('edit activity', () => {
                this.activityRegistry.set(activity.id, activity);
                this.activity = activity;
                this.submitting = false
            })
            history.push(`/activities/${activity.id}`)
        } catch (error) {
            toast.error('Problem submitting data');
            runInAction('edit acitivity error', () => {
                this.submitting = false;
            })
        }
    }

    @action deleteActivity = async (event: SyntheticEvent<HTMLButtonElement>, id: string) => {
        this.submitting = true;
        this.target = event.currentTarget.name;
        try {
            await agent.Activities.delete(id);
            runInAction('delete activity', () => {
                this.activityRegistry.delete(id);
                this.submitting = false;
                this.target = '';
            })
        } catch (error) {
            console.log(error);
            runInAction('delete activity error', () => {
                this.submitting = false;
                this.target = '';
            })
        }
    }
}