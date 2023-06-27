import { useParams, Link } from "react-router-dom";
import useFetch from './customHooks/useFetch.js';
const Invoice = () => {
    const { id } = useParams();
    const { data: invoices, isLoading, error } = useFetch(`https://localhost:7005/customers/getCustomerInvoices?_id=${id}`);
    return (
        <div className="invoice">
            <h1>Customer invoices</h1>
            {error && <div>{error}</div>}
            {isLoading && <div>Loading...</div>}
            {invoices && invoices.length === 0 && <h3>This customer has no invoices yet</h3> }
            {invoices && invoices.length !== 0 && <table>
                <thead>
                    <tr>
                        <th>Invoice Date</th>
                        <th>Details</th>
                        <th>Total Cost</th>
                    </tr>
                </thead>
                <tbody>
                    {invoices && invoices.map(invoice => (
                        <tr key={invoice.invoiceID}>
                            <td>{invoice.invoiceDate}</td>
                            <td>{invoice.details}</td>
                            <td>{invoice.totalCost}</td>
                            <td>
                                <button>Delete invoice</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>}
            <Link to="/customers">
                <button>Go back</button>
            </Link>
        </div>
    );
}

export default Invoice;