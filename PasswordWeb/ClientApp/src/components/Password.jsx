import React, { Component } from 'react';
//import { Button } from 'react-native-elements';
import { Service }  from "../data/Service";
import { stringLiteral } from '@babel/types';
import { ServiceComponent } from  './ServiceComponent';


export class Password extends React.Component {

      constructor(props) {
        super(props);
        this.state = { service: new Service(), key: "", password: "" };
      }


//#region Events 
      handleServiceChange(service) {
        this.setState({ service: service});
      }
      inputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
        this.setState({ 
            [name]: value
          });        
      }
      
      calcClick() {
        const response = fetch('PasswordApi/GetPassword', {
          method: 'POST',
          headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json',
            },
          body: JSON.stringify({
            service: this.state.service,
            key: this.state.key
            })
          }).then(response => response.json())
            .then(data => 
             {
               this.setState({ password: data.password})
               
             }
          );
          const response2 = fetch('PasswordApi/AddServiceParam', {
            method: 'POST',
            headers: {
              Accept: 'application/json',
              'Content-Type': 'application/json',
              },
            body: JSON.stringify({
              service: this.state.service
              })
            }).then( response =>
               {
                  this.setState({state: this.state})
               }
            );
      }
//#endregion

      render () {
        return (
        <div className="container">
           <h1>Password App</h1>
           <div className="form-group">
              <label className="col-form-label">Clave Maestra
                  <input name="key" type="text" className="form-control" value={this.state.key} onChange={(event) => this.inputChange(event)} />            
              </label>
           </div>
           <ServiceComponent service={this.state.service} inputChange={(service) => this.handleServiceChange(service)}></ServiceComponent>
           <button onClick={()=>this.calcClick()} >Calc</button>
           <div className="form-group">
           <label className="col-form-label">Password
              <input name="password" type="text" className="form-control" value={this.state.password} onChange={(event) => this.inputChange(event)} />            
            </label>
            </div>
        </div>);
      }
}