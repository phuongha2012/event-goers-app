import React, { useEffect, useContext } from 'react'
import { observer } from 'mobx-react-lite';
import { RootStoreContext } from '../../app/stores/rootStore';
import { toJS } from 'mobx';

const ActivityProfile = () => {
    const rootStore = useContext(RootStoreContext);
    const allActivities = rootStore.activityStore.activititesGoingByUser;
    useEffect(() => {
        console.log(allActivities);
    })
    return (
        <div>
            
        </div>
    )
}

export default observer(ActivityProfile);
