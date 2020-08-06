import { observable } from 'mobx';
import { createContext } from 'react';

class ActivityStore {
    @observable title = "Hi"
}

export default createContext(new ActivityStore())