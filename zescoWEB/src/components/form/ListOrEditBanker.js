import React from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { URL1 } from '../../services';
class RegistrationForm extends React.Component {
    state = {
        id: 0,  name: '', document: '', email: '',  phone: ''
    }
    componentDidMount() {
        if (this.props.user) {
            const { id, name, document, email, phone } = this.props.user
            this.setState({ id, name, document, email, phone });
        }
    }
    onChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }
    submitNew = e => {
        e.preventDefault();
        fetch(`${URL1}`, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: this.state.name,
                document: this.state.document,
                email: this.state.email,
                phone: this.state.phone
            })
        })
            .then(res => res.json())
            .then(user => {
                this.props.addUserToState(user);
                this.props.toggle();
            })
            .catch(err => console.log(err));
    }
    submitEdit = e => {
        e.preventDefault();
        fetch(`${URL1}/${this.state.id}`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: this.state.name,
                document: this.state.document,
                email: this.state.email,
                phone: this.state.phone
            })
        })
            .then(() => {
                this.props.toggle();
                this.props.updateUserIntoState(this.state.id);
            })
            .catch(err => console.log(err));
    }
    render() {
        return <Form onSubmit={this.props.user ? this.submitEdit : this.submitNew}>
            <FormGroup>
                <Label for="name">Name:</Label>  <Input type="text" name="name" 
                onChange={this.onChange} value={this.state.name === '' ? '' : this.state.name} />
            </FormGroup>
            <FormGroup>
                <Label for="document">MobileNo.:</Label>   <Input type="text" name="document" 
                onChange={this.onChange} value={this.state.document === null ? '' : this.state.document} />
            </FormGroup>
            <FormGroup>
                <Label for="email">Email:</Label><Input type="email" name="email" onChange={this.onChange}
                 value={this.state.email === null ? '' : this.state.email} />
            </FormGroup>
            <FormGroup>
                <Label for="phone">OfficeNo.:</Label> <Input type="text" name="phone" onChange={this.onChange}
                 value={this.state.phone === null ? '' : this.state.phone}
                    placeholder="+420-7743-48004" />
            </FormGroup>
            <Button>Send</Button>
        </Form>;
    }
}
export default RegistrationForm;