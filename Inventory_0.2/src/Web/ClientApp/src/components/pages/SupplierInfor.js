import React, { useState, Component } from 'react';
import { Card, Space, Breadcrumb, Form, Input, Button, DatePicker, Select, Descriptions, Modal, message } from 'antd';
import { useNavigate } from "react-router-dom";
import { SuppliersClient } from "../../web-api-client.ts";
import AddSupplier from './AddSupplier';


export default class SupplierInfor extends Component {
    formRef = React.createRef()
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            option: [],
            loading: true,
            open: false,
            selectedSupplier: {},
            modalText:"Content of the modal"
            
        }
    }
    async SuppliersData() {

        let client = new SuppliersClient();
        const data = await client.getAllSuppliers();
        const formattedOptions = data.map((supplier) => ({
            value: supplier.supplierId, // Replace 'id' with the property name in your warehouse data that serves as the option value
            label: supplier.supplierName, // Replace 'name' with the property name in your warehouse data that serves as the option label
        }));
        console.log(data)
        this.setState({ data: data, option: formattedOptions, loading: false });
    }
    componentDidMount() {
        this.SuppliersData();
    }

    render() {
        const { data, option, loading, open, modalText, selectedSupplier } = this.state;
       
        
        // const [confirmLoading, setConfirmLoading] = useState(false);
    
        const showModal = () => {
            this.setState({open : true})
        };
        const handleOk = async (values) => {
           
                let client = new SuppliersClient();
                const data = await client.createSuppliers(values);
                console.log(data);
                message.success('Thêm sản phẩm thành công.')
          

        };
        const handleCancel = () => {
            console.log('Clicked cancel button');
            this.setState({ open: false })
        };
        const handleSelect = (value) => {
            const selectedSupplier = data.find((supplier) => supplier.supplierId === value);
            this.setState({ loading: true, selectedSupplier })
            console.log(selectedSupplier)
            
        }
        return (
            <Card title="Thông tin nhà cung cấp" size="large">

                <Form.Item
                    name="SupplierId"

                    rules={[
                        {
                            required: true,
                        },
                    ]}
                >

                    
                    <Select
                        showSearch
                        style={{ width: 400 }}
                        placeholder="Search to Select"
                        optionFilterProp="children"
                        filterOption={(input, option) => (option?.label ?? '').includes(input)}
                        filterSort={(optionA, optionB) =>
                            (optionA?.label ?? '').toLowerCase().localeCompare((optionB?.label ?? '').toLowerCase())
                        }
                        options={option}
                        
                        onChange={handleSelect }

                    />
                  
                </Form.Item>
                <Modal
                    title="Thêm Nhà cung cấp"
                    open={this.state.open}
                    onCancel={handleCancel}
                    footer={null} 
                >
                 
                        <Form onFinish={handleOk}
                            style={{
                                maxWidth: 600,
                            }}  >
                        <Form.Item label="Tên nhà cung cấp" name="supplierName" rules={[{ required: true }]}>
                                <Input  />
                        </Form.Item>

                        <Form.Item label="Địa chỉ" name="address" rules={[{ required: true }]}>
                                <Input />
                        </Form.Item>

                        <Form.Item label="Số điện thoại" name="phone" rules={[{ required: true }]}>
                                <Input  />
                            </Form.Item>
                        
                        <div style={{ display: 'flex', justifyContent: 'flex-end' }}>
                        <Form.Item>
                            <Button
                                type="primary"
                                ghost
                                size="midle"
                                htmlType="submit"
                                
                            >
                                Lưu
                            </Button>
                            <Button
                                type="primary"
                                size="midle"
                                onClick={handleCancel}
                                
                            >
                                Thoát
                            </Button>
                        </Form.Item>
                        </div>
                        </Form>
                </Modal>
                {/*<Button type="primary" onClick={showModal}>*/}
                {/*    thêm nhà cung cấp*/}
                {/*</Button>*/}

                {this.state.loading ? (<Descriptions title="Thông tin nhà cung cấp" layout="vertical" >
                   
                     <Descriptions.Item label="Tên nhà cung cấp: ">{this.state.selectedSupplier.supplierName}</Descriptions.Item>
                    
                    
                    <Descriptions.Item label="Telephone">{this.state.selectedSupplier.phone}</Descriptions.Item>
                    <Descriptions.Item label="Address">
                        {this.state.selectedSupplier.address}
                        </Descriptions.Item>



                </Descriptions>)

                    : (<Descriptions title="Thông tin nhà cung cấp" />)}
               
            </Card>
        )
    }
};
