import React from 'react';
import { Routes, Route, useMatch } from 'react-router-dom';

import AuthorizeRoute from '../api-authorization/AuthorizeRoute';

import { UsersList } from './UsersList';
import { UsersAdd } from './UsersAdd';
import { UsersDelete } from './UsersDelete';
import { UsersEdit } from './UsersEdit';
import { UsersPasswordChange } from './UsersPasswordChange';

export function UsersRouter() {
    let match = useMatch();

    return (
        <Routes>
           
            <AuthorizeRoute path={`${match.path}/add`} element={<UsersAdd></UsersAdd>} />
            <Route path={`${match.path}/delete/:userId`} element={<UsersDelete></UsersDelete>} />
            <AuthorizeRoute path={`${match.path}/edit/:userId`} element={<UsersEdit></UsersEdit>} />
            <AuthorizeRoute path={`${match.path}/password-change/:userId`} component={<UsersPasswordChange></UsersPasswordChange>} />
            <AuthorizeRoute path={`${match.path}`} component={<UsersList></UsersList>} />
        </Routes>
    );
}