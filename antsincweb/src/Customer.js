import useFetch from './customHooks/useFetch.js';
import { Link } from 'react-router-dom';
const Customer = () => {
    const { data: customers, isLoading, error } = useFetch('https://localhost:7005/customers/getAllCustomers');
    return (
        <div className="customer">
            <h1>Customers</h1>
            {error && <div>{error}</div>}
            {isLoading && <div>Loading...</div>}
            <table>
                <thead>
                    <tr>
                        <th>DNI</th>
                        <th>Firstname</th>
                        <th>Lastname</th>
                        <th>Phone</th>
                    </tr>
                </thead>
                <tbody>   
                    {customers && customers.map(customer => (
                        <tr key={customer.dni}>
                            <td>{customer.dni}</td>
                            <td>{customer.firstName}</td>
                            <td>{customer.lastName}</td>
                            <td>{customer.phone}</td>
                            <td>
                                <Link to={`/modifyCustomer/${customer.dni}`}>
                                    <button>Modify customer</button>
                                </Link>  
                            </td>
                            <td>
                                <Link to={`/invoice/${customer.dni}`}>
                                    <button>See invoices</button>
                                </Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            
        </div>
    );
}

export default Customer;