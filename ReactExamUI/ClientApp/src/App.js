import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import './custom.css'
import { Header } from './components/Header';
import { LeftMenu } from './components/LeftMenu';
import { Landing } from './components/Landing';
import { Footer } from './components/Footer';


export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <div>
          <Header />
              <section>
                  <LeftMenu />
                  <Landing />
              </section>
          <Footer />
         </div>
      //<Layout>
      //  <Route exact path='/' component={Home} />
      //  <Route path='/counter' component={Counter} />
      //  <Route path='/fetch-data' component={FetchData} />
      //</Layout>
    );
  }
}
