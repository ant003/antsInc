import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Customer from "./Customer";
function App() {
    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path='/' element={<Customer /> }/>
                </Routes>
            </div>
      </Router>
     
  );
}

export default App;
