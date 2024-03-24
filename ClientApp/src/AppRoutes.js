import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { FarmerHelpRequests } from "./components/FarmerHelpRequests";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/help-farmer',
    element: <FarmerHelpRequests />
  },
];

export default AppRoutes;
