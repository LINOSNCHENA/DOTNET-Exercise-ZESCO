import React, { Component, Fragment } from 'react';
import { Button, Modal, ModalHeader, ModalBody } from 'reactstrap';
import ListOrEditBanker from './ListOrEditBanker';


class AddOrEditBanker extends Component {
    state = {    modal: false  }
    toggle = () => {
        this.setState(previous => ({  modal: !previous.modal }));
    }
    render() {
        const isNew = this.props.isNew;
        let title = 'Update Banker';
        let button = '';
        if (isNew) {
            title = 'Add Banker';
            button = <Button
                color="success"
                onClick={this.toggle}
                style={{ minWidth: "200px" }}>Add</Button>;
        } else {
            button = <Button
                color="warning"
                onClick={this.toggle}>Edit</Button>;
        }
        return <Fragment>
            {button}
            <Modal isOpen={this.state.modal} toggle={this.toggle} className={this.props.className}>
                <ModalHeader toggle={this.toggle}>{title}</ModalHeader>
                <ModalBody>
                    <ListOrEditBanker
                        addUserToState={this.props.addUserToState}
                        updateUserIntoState={this.props.updateUserIntoState}
                        toggle={this.toggle}
                        user={this.props.user} />
                </ModalBody>
            </Modal>
        </Fragment>;
    }
}
export default AddOrEditBanker;