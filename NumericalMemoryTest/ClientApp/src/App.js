import React, { Component } from 'react';
import { Route, Redirect, Switch } from 'react-router';
import { Layout } from './components/Layout';

import './custom.css'
import { NumericalTest } from './components/NumericalTest';
import { Instructions } from './components/Instructions';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Switch>
          <Route exact path='/instructions' component={Instructions} />
          <Route exact path='/test' component={NumericalTest} />
          <Redirect to="/instructions" />
        </Switch>
      </Layout>
    );
  }
}
