import React, { useContext } from "react";
import { observer } from "mobx-react-lite";
import { RootStoreContext } from "../../app/stores/rootStore";
import { toJS } from "mobx";
import { Header, Tab, Card } from "semantic-ui-react";
import { Link } from "react-router-dom";

const ActivityProfile = () => {
  const rootStore = useContext(RootStoreContext);
  const activitiesToGo = rootStore.activityStore.activititesGoingByUser;
  const activitiesToHost = rootStore.activityStore.activititesHostingByUser;
  console.log(activitiesToGo);
  return (
    <Tab.Pane>
      <Header size="medium">Going:</Header>
      {activitiesToGo.map(activity => (
          <Card
          fluid
          color='pink'
          key={activity.id}
          as={Link}
          to={`/activities/${activity.id}`}
          header={activity.title}
          meta={activity.date.toDateString()}
          description={activity.description}
        />
      ))}

      
      <Header size="medium">Hosting:</Header>
      {activitiesToHost.map(activity => (
          <Card
          fluid
          color='orange'
          key={activity.id}
          as={Link}
          to={`/activities/${activity.id}`}
          header={activity.title}
          meta={activity.date.toDateString()}
          description={activity.description}
        />
      ))}
    </Tab.Pane>
  );
};

export default observer(ActivityProfile);
