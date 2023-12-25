import { Link, NavLink } from "react-router-dom";
import clsx from "clsx";
import "./navbar.css"



function Navbar() {

  const navLinkClasses = ({ isActive }: { isActive: boolean }) =>
    clsx('nav-link', {
      'text-secondary': !isActive,
      'text-info': isActive,
    });

  return (
    <nav className="navbar fixed-top navbar-expand-lg " style={{backgroundColor: "#e3f2fd"}}>
      <div className="container-fluid">
        <a className="navbar-brand" href="/">AirportsDistance</a>
        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarScroll" aria-controls="navbarScroll" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarScroll">
          <ul className="navbar-nav me-auto my-2 my-lg-0 navbar-nav-scroll" >
            <li className="nav-item">
              <NavLink className={navLinkClasses} to="/">Home</NavLink>
            </li>
            <li className="nav-item dropdown">              
            </li>            
          </ul>  
            <ul className="navbar-nav">
              <li className="nav-item">
                <NavLink to="/sign-in" className={navLinkClasses}>
                  Sign in
                </NavLink>
              </li>
              <li className="nav-item ms-2">
                <NavLink to="/sign-up" className={navLinkClasses}>
                  Sign up
                </NavLink>
              </li>
            </ul>              
          {/* <form className="d-flex" role="search">
            <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search"/>
            <button className="btn btn-outline-success" type="submit">Search</button>
          </form> */}
        </div>
      </div>
    </nav>
  );
}

export default Navbar;