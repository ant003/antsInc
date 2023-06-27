import { Link } from 'react-router-dom';

const Home = () => {
    return (
        <div className="home">
            <h1>Welcome to Ants INC</h1>
            <Link to="/customers">
                <button>See all the customers</button>
            </Link>
        </div>     
    );
}

export default Home;