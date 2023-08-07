import React from 'react';

import { theme } from 'antd';
const Import = () => {
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

export default Import;