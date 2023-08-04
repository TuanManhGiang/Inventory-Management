import React, { useState } from 'react';
import { DownOutlined } from '@ant-design/icons';
import { Button, Col, Form, Input, Row, Select, Space, theme } from 'antd';
const ExImport = () => {
    const { token } = theme.useToken();
    const listStyle = {
        lineHeight: '200px',
        textAlign: 'center',
        background: token.colorFillAlter,
        borderRadius: token.borderRadiusLG,
        marginTop: 8,
    };
    return (


        <div style={listStyle}></div>

    );
};

export default ExImport;