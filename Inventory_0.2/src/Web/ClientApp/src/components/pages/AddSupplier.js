import React, { useState, Component } from 'react';
import { Button, Modal, Select } from 'antd';
export default class AddSupplier extends Component {
    render() {
        return (
            <Select
                showSearch
                id="city"
                style={{ width: 400 }}
                placeholder="Search to Select"
                optionFilterProp="children"
                filterOption={(input, option) => (option?.label ?? '').includes(input)}
                filterSort={(optionA, optionB) =>
                    (optionA?.label ?? '').toLowerCase().localeCompare((optionB?.label ?? '').toLowerCase())
                }



            />
        );
}
    
}
