import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Customer from "./Customer";
import Home from './Home';
import ModifyCustomer from './ModifyCustomer/ModifyCustomer';
import Invoice from './Invoice';
function App() {
    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path='/' element={<Home/>}/>
                    <Route path='/customers' element={<Customer />} />
                    <Route path='/modifyCustomer/:id' element={<ModifyCustomer />} />
                    <Route path='/invoice/:id' element={<Invoice />} />
                </Routes>
            </div>
      </Router>
     
  );
}

export default App;
