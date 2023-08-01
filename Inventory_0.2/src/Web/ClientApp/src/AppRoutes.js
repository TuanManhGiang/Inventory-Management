import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";

import { Layout } from "./components/Layout";
import LoginForm from "./components/pages/LoginPage";

const AppRoutes = [
  {
    index: true,
        element: <LoginForm></LoginForm>
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
    {
        path: '/DasboardPage',
        element:<Layout></Layout>
    }
    
];

export default AppRoutes;
