const ModifyForm = ({ isPending, formValues, handleChange, handleSubmit }) => {
    return (
        <div>
            <form onSubmit={handleSubmit}>
                <label>DNI</label>
                <input
                    type="text"
                    required
                    value={formValues.dni}
                    name={"dni"}
                    onChange={handleChange}
                />
                <label>First Name</label>
                <input
                    type="text"
                    required
                    value={formValues.firstName}
                    name={"firstName"}
                    onChange={handleChange}
                />
                <label>Last Name</label>
                <input
                    type="text"
                    required
                    value={formValues.lastName}
                    name={"lastName"}
                    onChange={handleChange}
                />
                <label>Phone</label>
                <input
                    type="text"
                    required
                    value={formValues.phone}
                    name={"phone"}
                    onChange={handleChange}
                />
                {!isPending && <button>Save changes</button>}
                {isPending && <button disabled>Saving changes...</button>}
            </form>
        </div>
    )
}

export default ModifyForm;