import React, { Component } from "react";

import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";
import { UsersRouter } from "./components/users/UsersRouter";
import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { ApplicationPaths } from "./components/api-authorization/ApiAuthorizationConstants";
import DashboardPage from "./components/Dashboard";

import "./custom.css";

import {
  Routes,
  Route,
  RouterProvider,
    createBrowserRouter,
    Navigate
} from "react-router-dom";

const router = createBrowserRouter([
  { path: "/login", element: <DashboardPage></DashboardPage> },
  { path: "/", element: <Home></Home> },
]);
export default class App extends Component {
  static displayName = App.name;
    constructor(props) {
        super(props);
        this.state = {
            isAuthenticated: false, // Assume the user is not authenticated initially
        };
    }



    render() {
        const { isAuthenticated } = this.state;
    return (
        <RouterProvider router={router}>

            {if !false && <Navigate to="/login" />} {/* Redirect to login page if not authenticated */}



        </RouterProvider>
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
