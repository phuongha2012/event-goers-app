import React, { useContext } from "react";
import { observer } from "mobx-react-lite";
import { RootStoreContext } from "../../app/stores/rootStore";
import { toJS } from "mobx";
import { Header, Tab, Card, Divider } from "semantic-ui-react";
import { Link } from "react-router-dom";

const ActivityProfile = () => {
  const rootStore = useContext(RootStoreContext);
  const activitiesToGo = rootStore.activityStore.activititesGoingByUser;
  const activitiesToHost = rootStore.activityStore.activititesHostingByUser;
  return (
    <Tab.Pane>
      <Header size="medium">Going:</Header>
      {activitiesToGo.length > 0 ? (
        activitiesToGo.map((activity) => (
          <Card
            fluid
            color="pink"
            key={activity.id}
            as={Link}
            to={`/activities/${activity.id}`}
            header={activity.title}
            meta={activity.date.toDateString()}
            description={activity.description}
          />
        ))
      ) : (
        <p style={{ fontSize: "17px", color: "grey" }}>
          No activity to go. Try browsing our activity list now
        </p>
      )}
      <Divider />
      <Header size="medium">Hosting:</Header>
      {activitiesToHost.length > 0 ? (
        activitiesToHost.map((activity) => (
          <Card
            fluid
            color="orange"
            key={activity.id}
            as={Link}
            to={`/activities/${activity.id}`}
            header={activity.title}
            meta={activity.date.toDateString()}
            description={activity.description}
          />
        ))
      ) : (
        <p style={{ fontSize: "17px", color: "grey" }}>
          You haven't created an activity yet!
        </p>
      )}
    </Tab.Pane>
  );
};

export default observer(ActivityProfile);
