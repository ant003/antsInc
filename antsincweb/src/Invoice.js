import { useParams, Link } from "react-router-dom";
import useFetch from './customHooks/useFetch.js';
import { useState } from "react";
const Invoice = () => {
    const [deleted, setDeleted] = useState(false);
    const { id } = useParams();
    const { data: invoices, isLoading, error } = useFetch(`https://localhost:7005/customers/getCustomerInvoices?_id=${id}`);

    /**
     * Called when the form button is clicked
     * Does a POST request to delete the invoice from the database
     */
    const deleteInvoice = (e, invoiceID) => {
        e.preventDefault();

        fetch(`https://localhost:7005/invoices/deleteAnInvoice?_id=${invoiceID}`, {
            method: 'POST',
            headers: { "Content-Type": "application/json" }
        })
            .then(() => {
                console.log('Invoice deleted');
                setDeleted(true);
            })
    }

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
                                <button onClick={(e) => deleteInvoice(e, invoice.invoiceID)}>
                                    Delete invoice
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>}
            <Link to="/customers">
                <button onClick={() => setDeleted(false)}>Go back</button>
            </Link>
            {deleted && <p>Invoice deleted</p>}
        </div>
    );
}

export default Invoice;