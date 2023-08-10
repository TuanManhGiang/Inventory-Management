import React from 'react';
import { Card, Space, Breadcrumb, Form, Input, Button, Col, Row } from 'antd';
import { useNavigate } from "react-router-dom";
import { ProductsClient } from "../../web-api-client.ts";
import InvoiceInfor from './InvoiceInfor'; 
import SupplierInfor from './SupplierInfor';
import ProductInvoiceInfor from './ProductInvoiceInfor';
const layout = {
    labelCol: {
        span: 8,
    },
    wrapperCol: {
        span: 16,
    },
};


const ListImport = () => {
    const navigate = useNavigate();
    const [form] = Form.useForm();
    const onFinish = async (values) => {
        try {
            //let client = new ProductsClient();
            //const data = await client.createProduct(values);
            console.log(values);

            navigate("/AllProduct")
        } catch (error) {
            //handle api error
            console.error('Error:', error);
        }

    };
    const onReset = () => {
        navigate("/AllProduct")
    };


    return (
        <div>
            <Breadcrumb
                style={{
                    margin: "0 16px",
                    fontSize: "14px",
                    margin: '16px'
                }}
                items={[
                    {
                        title: 'Nhập Hàng',
                    },
                    {
                        title: "Danh sách đơn nhập hàng",
                    },
                    {
                        title: "Thêm đơn nhập hàng"
                    },

                ]}
            />
            <Form onFinish={onFinish}>
                <Space
                    direction="vertical"
                    size="middle"
                    style={{
                        display: 'flex',
                        margin: '16px',
                    }}
                >
                    <Space
                        direction="horizontal"
                        size="middle"

                    >
                        <Row gutter={16}>
                        <Col span={9}>
                            <InvoiceInfor />
                        </Col>
                        <Col span={15}>
                            <SupplierInfor />
                            </Col>
                        </Row>
                    </Space>
                    <ProductInvoiceInfor></ProductInvoiceInfor>
                    
                </Space>
                <div style={{ display: 'flex', justifyContent: 'flex-end' }}>
                    <Form.Item>
                        <Button
                            type="primary"
                            ghost
                            size="large"
                            htmlType="submit"
                            style={{ width: '150px', marginRight: '10px' }}
                        >
                            Lưu
                        </Button>
                        <Button
                            type="primary"
                            size="large"
                            onClick={onReset}
                            style={{ width: '150px' }}
                        >
                            Thoát
                        </Button>
                    </Form.Item>
                </div>
            </Form>
        </div>
    )
};
export default ListImport;