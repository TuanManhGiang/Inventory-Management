import React, { Component,useEffect } from "react";

import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";
import { UsersRouter } from "./components/users/UsersRouter";
import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { ApplicationPaths } from "./components/api-authorization/ApiAuthorizationConstants";
import DashboardPage from "./components/Dashboard";
import LoginPage from "./components/pages/LoginPage"

import "./custom.css";

import {
  Routes,
  Route,
  RouterProvider,
    createBrowserRouter,
    Navigate
} from "react-router-dom";
import { Login } from "./components/api-authorization/Login";

const router = createBrowserRouter(
    [
        {
            path: "/", element: <DashboardPage></DashboardPage>,
            children: [
                
                {
                    path: 'authentication', element: <LoginPage></LoginPage>
                }
            ]


        }
       
    ]);


export default class App extends Component {
    static displayName = App.name;

    //constructor(props) {
    //    super(props);
    //    this.state = {
    //        isAuthenticated: false,
    //    };
    //}

    //componentDidMount() {
    //    // Replace this with your actual authentication check
    //    // For example, check for a session token or user credentials here
    //    // and update the `isAuthenticated` state accordingly

    //     // Replace this with your actual authentication check result

    //    if (!isAuthenticated) {
    //        const loginUrl = "Identity/Account/Login"; // Replace this with your actual login page URL
    //        window.location.href = loginUrl;
    //    } else {
    //        // User is authenticated, update the state accordingly
    //        this.setState({ isAuthenticated: true });
    //    }
    //}
    render() {


        return (
        <DashboardPage></DashboardPage>
        //<RouterProvider  router={router}>

        //</RouterProvider>
      //<Layout>
      //<Routes>
      //        <Route path='/' element={<DashboardPage />} />

      //</Routes>
      //    <AuthorizeRoute path='/fetch-data' component={<FetchData></FetchData>} />
      //    <AuthorizeRoute path='/users' component={<UsersRouter></UsersRouter>} />
      //</Layout>
    );
  }
}
