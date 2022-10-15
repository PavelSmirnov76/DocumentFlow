import Tab from 'react-bootstrap/Tab'
import Tabs from 'react-bootstrap/Tabs';
import PositionPage from './pages/PositionPage'
import PersonPage from './pages/PersonPage'
import EmployeePage from "./pages/EmployeePage";
import InternalDocumentPage from "./pages/InternalDocumentPage";
import VerificationSignaturePage from "./pages/VerificationSignaturePage";

function App() {
  return (
      <div>
          <Tabs
              defaultActiveKey="internalDocuments"
              id="uncontrolled-tab-example"
              className="mb-3"
          >
              <Tab eventKey="positions" title="Должности">
                  <PositionPage />

              </Tab>

              <Tab eventKey="persons" title="Личности">
                  <PersonPage />
              </Tab>
              <Tab eventKey="employees" title="Работники">
                  <EmployeePage />
              </Tab>
              <Tab eventKey="internalDocuments" title="Внутренние документы">
                  <InternalDocumentPage />
              </Tab>
              <Tab eventKey="CheckSign" title="Проверка подписи">
                  <VerificationSignaturePage />
              </Tab>
          </Tabs>

      </div>
  );
}

export default App;
