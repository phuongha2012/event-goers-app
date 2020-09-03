import React, { useEffect, useContext } from 'react'
import { observer } from 'mobx-react-lite';
import { RootStoreContext } from '../../app/stores/rootStore';
import { toJS } from 'mobx';

const ActivityProfile = () => {
    const rootStore = useContext(RootStoreContext);
    const activitiesToGo = rootStore.activityStore.activititesGoingByUser;
    const activitiesToHost = rootStore.activityStore.activititesHostingByUser;
    useEffect(() => {
        console.log(activitiesToHost);
    })
    return (
        <div>
            
        </div>
    )
}

export default observer(ActivityProfile);
