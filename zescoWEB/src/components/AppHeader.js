import React, { Component } from 'react'; // 1
import logo from '../zesco.png';
import {
    Navbar, NavbarBrand, NavbarToggler, Collapse, Nav,
    NavItem, NavLink, UncontrolledDropdown,
    DropdownToggle, DropdownMenu, DropdownItem
} from 'reactstrap';
class AppHeader extends Component {
    state = { isOpen: false };
    toggle = this.toggle.bind(this);
    toggle() {
        this.setState({
            isOpen: !this.state.isOpen
        })
    }
    render() {
        return <Navbar color="dark" dark expand="md">
            <NavbarBrand href="/">
                <img src={logo}   alt="ZESCO LOGO MISSING"/>

            </NavbarBrand>
            <NavbarToggler onClick={this.toggle} />
            <Collapse isOpen={this.state.isOpen} navbar>
                <Nav className="ml-auto" navbar>
                    <NavItem> <NavLink href="/">Zesco link1</NavLink>   </NavItem>
                    <UncontrolledDropdown nav inNavbar>
                        <DropdownToggle nav caret>   ZESCO  World  </DropdownToggle>
                        <DropdownMenu right>
                            <DropdownItem href="/">About Us link2</DropdownItem>
                            <DropdownItem>Make a Booking link3</DropdownItem>
                        </DropdownMenu>
                    </UncontrolledDropdown>
                </Nav>
            </Collapse>
        </Navbar>;
    }
}
export default AppHeader; // 8