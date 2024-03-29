
import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';


import authService from './api-authorization/AuthorizeService'
import { UserRoles } from './api-authorization/ApiAuthorizationConstants';
import {
    Space,
    Typography,
    Breadcrumb,
    Layout,
    Menu,
    theme,
    Row,
    Col,
    Avatar,
} from "antd";
const { Header, Content, Footer, Sider } = Layout;
class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            hasAdminRole: false,
            collapsed: true
        };
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
    }

    async populateState() {
        const hasAdminRole = await authService.hasRole(UserRoles.Administrator);
        this.setState({
            hasAdminRole
        });
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
      
        return (
  
            <Header
                style={{
                    margin: "0 16px",
                    background: "#fff",
                }}
            >
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/">User Management React</NavbarBrand>
                        <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                                </NavItem>
                                {
                                    this.state.hasAdminRole &&
                                    <NavItem>
                                        <NavLink tag={Link} className="text-dark" to="/users">Users</NavLink>
                                    </NavItem>
                                }
                                <LoginMenu>
                                </LoginMenu>
                              
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </Header>
        );
    }
}

export default  NavMenu;