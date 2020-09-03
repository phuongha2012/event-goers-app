import React from 'react'
import { Tab } from 'semantic-ui-react'
import ProfilePhotos from './ProfilePhotos'
import ActivityProfile from './ActivityProfile'

const panes = [
    {menuItem: 'Activities', render: () => <ActivityProfile />},
    {menuItem: 'Photos', render: () => <ProfilePhotos />}  
]

const ProfileContent = () => {
    return (
        <Tab 
            menu={{fluid: true, vertical: true}}
            menuPosition='right'
            panes={panes}
        />
    )
}

export default ProfileContent
