import React from "react";
import { IAttendee } from "../../../app/models/activity";

interface IProps {
  attendees: IAttendee[];
}

const ActivityListItemAttendees: React.FC<IProps> = ({ attendees }) => {
  return (
      <p>{attendees.length} {attendees.length === 1 ? "person" : "people"}{" "}
      going</p>
  );
};

export default ActivityListItemAttendees;
