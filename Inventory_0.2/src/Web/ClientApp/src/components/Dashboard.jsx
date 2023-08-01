import React, { useState } from "react";

import {
    HomeOutlined,
    ReconciliationOutlined,
    FileOutlined,
    ShopOutlined,
    TeamOutlined,
    UserOutlined,
    FundProjectionScreenOutlined,
} from "@ant-design/icons";
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
import { Navigate, Router, Routes, Route, useNavigate } from "react-router-dom";
import Home from "./Home";
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
        getItem("Tom", "Home"),
        getItem("Bill", "4"),
        getItem("Alex", "5"),
    ]),
    getItem("Kho", "4", <HomeOutlined />, [
        getItem("Danh sách sản phẩm", "/Home"),
        getItem("Quản lý Kho"),
        getItem("Kiểm hàng"),
    ]),
    getItem("Sản Phẩm", "1", <ShopOutlined />, [
        getItem("Danh sách sản phẩm"),
        getItem("Quản lý Kho"),
        getItem("Kiểm hàng"),
        getItem("Chuyển hàng"),
        getItem("Nhà cung cấp"),
    ]),
    getItem("Nhập Hàng", "2", <ReconciliationOutlined />, [
        getItem("Đặt hàng nhập"),
        getItem("Nhập hàng"),
    ]),
    getItem("Xuất Hàng", "3", <ReconciliationOutlined />, [
        getItem("Đặt hàng xuất"),
        getItem("Xuất hàng"),
    ]),

    getItem("Báo cáo", "6", <FundProjectionScreenOutlined />, [
        getItem("Team 1", "6"),
        getItem("Team 2", "8"),
    ]),
];

function DashboardPage() {
    const [collapsed, setCollapsed] = useState(false);
    const {
        token: { colorBgContainer },
    } = theme.useToken();

    const navigate = useNavigate();
    function Content() {
        return (
     
                <Routes>
                   
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
                        console.log("click menu");
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
                    <Text
                        strong
                        style={{
                            fontSize: "24px",
                        }}
                    >
                        Danh Sách Sản Phẩm
                    </Text>
                </Header>
                <Content></Content>
                <Footer style={{ textAlign: "center" }}></Footer>
            </Layout>
        </Layout>
    );
}

export default DashboardPage;
