import React, { useState } from "react";

import {
    HomeOutlined,
    ReconciliationOutlined,
    FileOutlined,
    ShopOutlined,
    TeamOutlined,
    UserOutlined,
    FundProjectionScreenOutlined,
    MenuUnfoldOutlined
} from "@ant-design/icons";
import { LoginMenu } from './api-authorization/LoginMenu';
import {
    Space,
    Typography,
    Breadcrumb,
    Layout,
    Menu,
    theme,
    Row,
    Col,
    Avatar
   
} from "antd";
import { Navigate, Router, Routes, Route, useNavigate } from "react-router-dom";
import Home from "./Home";
import ListProduct from "./pages/ListProduct"
import CheckProduct from "./pages/CheckProduct"
import AllProduct from "./pages/AllProduct"
import Import from "./pages/Import"
import ListImport from "./pages/ListImport"
import Export from "./pages/Import"
import ListExport from "./pages/ListImport"
import InventoryStatement from "./pages/InventoryStatement"
import CreateProduct from "./pages/CreateProduct";


const { Text, Link } = Typography;

const { Header, Content, Footer, Sider } = Layout;

function getItem(label, key, icon, children, url) {
    return {
        key,
        icon,
        children,
        label,
        url,
    };
}

const items = [
    getItem("User", "sub1", <UserOutlined />, [
        getItem("Danh Sach ", "Home")

    ]),
    getItem("Kho", "4", <HomeOutlined />, [
        getItem("Danh sách sản phẩm", "ListProduct"),
       /* getItem("Quản lý Kho"),*/
        getItem("Kiểm hàng","CheckProduct"),
    ]),
    getItem("Sản Phẩm", "1", <ShopOutlined />, [
        getItem("Danh sách sản phẩm","AllProduct"),
        getItem("Quản lý Kho","WareHouseProduct"),
        getItem("Chuyển hàng"),
        getItem("Nhà cung cấp"),
    ]),
    getItem("Nhập Hàng", "2", <ReconciliationOutlined />, [
        getItem("Đặt hàng nhập","ListImport"),
        getItem("Nhập hàng","Import"),
    ]),
    getItem("Xuất Hàng", "3", <ReconciliationOutlined />, [
        getItem("Đặt hàng xuất","ListExport"),
        getItem("Xuất hàng","Export"),
    ]),

    getItem("Báo cáo", "6", <FundProjectionScreenOutlined />, [
        getItem("Báo Cáo Tồn Kho", "InventoryStatement"),
        getItem("Team 2", "8"),
    ]),
];
const findLabelFromKey = (key) => {
    for (const item of items) {
            for (const child of item.children) {
                if (child.key === key) {
                    return child.label;
                }
            }
    }
    return null;
};
function DashboardPage() {
    const [collapsed, setCollapsed] = useState(false);
    const [itemLabel, setItemLabel] = useState("Danh Sách Sản Phẩm");
    const {
        token: { colorBgContainer },
    } = theme.useToken();

    const navigate = useNavigate();
    function Content() {
        return (
     
                <Routes>
                <Route path='/ListProduct' element={<ListProduct></ListProduct>} />
                <Route path='/CheckProduct' element={<CheckProduct></CheckProduct>} />
                <Route path='/AllProduct' element={<AllProduct></AllProduct>} />
                <Route path='/WareHouseProduct' element={<ListProduct></ListProduct>} />
                <Route path='/ListImport' element={<ListImport></ListImport>} />
                <Route path='/Import' element={<Import></Import>} />
                <Route path='/ListExport' element={<ListExport></ListExport>} />
                <Route path='/Export' element={<Export></Export>} />
                <Route path='/InventoryStatement' element={<InventoryStatement></InventoryStatement>} />
                <Route path='/InventoryReport' element={<Export></Export>} />
                <Route path='/CreateProduct' element={<CreateProduct></CreateProduct>} />
                </Routes>
        );
    }
    return (
        <Layout
            style={{
                minHeight: "100vh",
            }}
        >
            <Sider
                collapsible
                collapsed={collapsed}
                onCollapse={(value) => setCollapsed(value)}
            >
                <div className="demo-logo-vertical" />
                <Menu
                    theme="dark"
                    defaultSelectedKeys={["Home"]}
                    mode="inline"
                    items={items}
                    onClick={({ key }) => {
                        setItemLabel(findLabelFromKey(key))
                        navigate(key);
                        
                    }}
                ></Menu>
            </Sider>
            <Layout>
                <Header
                    style={{
                        margin: "0 16px",
                        background: "#fff",
                    }}
                >
                    <Row>
                        <Col md={18}>

                            <Text
                                strong
                                style={{
                                    fontSize: "24px",
                                }}
                            >
                                {itemLabel }
                            </Text>
                        </Col>
                        <Col md={6}>
                            <div>
                                <Avatar size='default' icon={<UserOutlined></UserOutlined>}>
                                </Avatar> 
                            </div>
                       
                        </Col>

                    </Row>
                </Header>
                <Content></Content>
                <Footer style={{ textAlign: "center" }}></Footer>
            </Layout>
        </Layout>
    );
}

export default DashboardPage;
