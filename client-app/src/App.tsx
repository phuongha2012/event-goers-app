import React from 'react';
import logo from './logo.svg';
import { Header, Icon } from 'semantic-ui-react';
import './App.css';

function App() {
  return (
    <div className="App">
      <Header as='h2'>
        <Icon name='plug' />
        <Header.Content>Event Goers</Header.Content>
      </Header>
    </div>
  );
}

export default App;
