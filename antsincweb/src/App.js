import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Customer from "./Customer";
import Home from './Home';
function App() {
    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path='/' element={<Home/>} />
                    <Route path='/customers' element={<Customer/>} />
                </Routes>
            </div>
      </Router>
     
  );
}

export default App;
