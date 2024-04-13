import { Home } from "./components/Home";
import { FarmerHelpRequests } from "./components/FarmerHelpRequests";
import { FarmerHelpRequestCreation } from "./components/FarmerHelpRequestCreation";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/help-farmer',
    element: <FarmerHelpRequests />
  },
  {
    path: '/create-help-request',
    element: <FarmerHelpRequestCreation />
  }
];

export default AppRoutes;
