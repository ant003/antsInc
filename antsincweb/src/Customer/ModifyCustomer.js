import { useParams, Link } from "react-router-dom";
import useFetch from '../customHooks/useFetch.js';
import { useState, useEffect } from "react";
import ModifyForm from "./ModifyForm.js";

const ModifyCustomer = () => {
    const [isPending, setIsPending] = useState(false);
    const [modified, setModified] = useState(false);
    const { id } = useParams();
    const { data: customer, isLoading, error } = useFetch(`https://localhost:7005/customers/getACustomer?dni=${id}`);

    const [formValues, setFormValues] = useState({
        dni: '',
        firstName: '',
        lastName: '',
        phone: ''
    });

    useEffect(() => {
        if (customer != null) {
            setFormValues({
                dni: customer[0].dni,
                firstName: customer[0].firstName,
                lastName: customer[0].lastName,
                phone: customer[0].phone
            });
        }
    }, [customer]);

    /**
     * Called each time any of the values on the input are changed
     * It updates the values in the form state
     */
    const handleChange = (event) => {
        const { name, value } = event.target;
        setFormValues({ ...formValues, [name]: value });
    }

    /**
     * Called when the form button is clicked
     * Does a POST request to send the data to the database
     */
    const handleSubmit = (e) => {
        e.preventDefault();
        setIsPending(true);

        fetch('https://localhost:7005/customers/modifyCustomer', {
            method: 'POST',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(formValues)
        })
            .then(() => {
                setIsPending(false);
                console.log('Customer modified');
                setModified(true);
            })
    }

    return (
        <div className="modifyCustomer">
            <h1>Modify Customer</h1>
            <h2>{id}</h2>
            {isLoading && <p>Loading...</p>}
            {error && <p>Could not get the customer details</p>}
            <ModifyForm
                isPending={isPending}
                formValues={formValues}
                handleChange={handleChange}
                handleSubmit={handleSubmit}
            />
            <Link to="/customers">
                <button onClick={()=> setModified(false)}>Go back</button>
            </Link>
            {modified && <p>Customer updated</p>}
            
        </div>
    );
} 

export default ModifyCustomer;