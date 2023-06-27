import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Customer from "./Customer";
import Home from './Home';
import ModifyCustomer from './Customer/ModifyCustomer';
function App() {
    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path='/' element={<Home/>}/>
                    <Route path='/customers' element={<Customer />} />
                    <Route path='/modifyCustomer/:id' element={<ModifyCustomer />} />
                </Routes>
            </div>
      </Router>
     
  );
}

export default App;
