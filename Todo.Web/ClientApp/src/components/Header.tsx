import React from "react";
import { Nav, Navbar } from "react-bootstrap";
import { NavLink } from "react-router-dom";

export const Header = () => (
  <Navbar bg="light" expand="lg">
    <Navbar.Brand>Todo App</Navbar.Brand>
    <Navbar.Toggle aria-controls="basic-navbar-nav" />
    <Navbar.Collapse id="basic-navbar-nav">
      <Nav className="mr-auto">
        <NavLink exact to="/" className="nav-link" activeClassName="active">
          Home
        </NavLink>
        <NavLink exact to="/service" className="nav-link" activeClassName="active">
          Service
        </NavLink>
        <NavLink exact to="/about" className="nav-link" activeClassName="active">
          About
        </NavLink>
      </Nav>
    </Navbar.Collapse>
  </Navbar>
);
