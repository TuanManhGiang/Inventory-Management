import React, { Component, Fragment } from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import authService from './AuthorizeService';
import { ApplicationPaths } from './ApiAuthorizationConstants';


class LoginMenuPlain extends Component {
    constructor(props) {
        super(props);

        this.state = {
            isAuthenticated: false,
            userName: null
        };
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            isAuthenticated,
            userName: user && user.name
        });
    }

    render() {
        const { isAuthenticated, userName } = this.state;
        if (!isAuthenticated) {
            const registerPath = `${ApplicationPaths.Register}`;
            const loginPath = `${ApplicationPaths.Login}`;
            return this.anonymousView(registerPath, loginPath);
        } else {
            const profilePath = `${ApplicationPaths.Profile}`;
            const logoutPath = { pathname: `${ApplicationPaths.LogOut}`, state: { local: true } };
            return this.authenticatedView(userName, profilePath, logoutPath);
        }
    }

	authenticatedView(userName, profilePath, logoutPath) {
		const { t, } = this.props;

        return (<Fragment>
            <NavItem>
				<NavLink tag={Link} className="text-dark" to={profilePath}>
					{t('Hello')} {userName}
				</NavLink>
            </NavItem>
            <NavItem>
				<NavLink tag={Link} className="text-dark" to={logoutPath}>
					{t('Logout')}
				</NavLink>
            </NavItem>
        </Fragment>);
    }

    anonymousView(registerPath, loginPath) {
        return (<Fragment>
            <NavItem>
                <a className="nav-link text-dark" href="/Identity/Account/Register">register</a>
            </NavItem>
            <NavItem>
                 <a className="nav-link text-dark" href="/Identity/Account/Login">Login</a>
            </NavItem>
            <NavItem>
                <a className="nav-link text-dark" href="/Identity/Account/Manage">Account</a>
            </NavItem>
        </Fragment>);
    }
}

export const LoginMenu = (LoginMenuPlain);
