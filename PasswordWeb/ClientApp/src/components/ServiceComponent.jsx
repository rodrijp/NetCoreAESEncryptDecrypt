import React, { Component } from 'react';
import { Service }  from "../data/Service";
import { stringLiteral } from '@babel/types';
import Autocomplete from 'react-autocomplete';

export class ServiceComponent extends React.Component {
    constructor(props) {
        super(props);
        this.serviceList = [];
        this.state = { service: this.props.service, serviceFiltered: [] }
      }

      GetServices() {
        fetch('PasswordApi/GetServices',  {
          headers : { 
            'Content-Type': 'application/json',
            'Accept': 'application/json'
            }
          })
          .then(response => response.json())
          .then(data => 
          {
            this.serviceList = data;
            //this.setState({ serviceFiltered: data })
          }
        );
      }
      componentDidMount() {
        this.GetServices();
      }
      componentDidUpdate() {
        this.GetServices();
      }
      matchServiceToTerm(service, value) {
        return (service.name.toLowerCase().indexOf(value.toLowerCase()) !== -1);
      }
      
      serviceFiltered(value) {
        return this.serviceList.filter( (service) => this.matchServiceToTerm(service, value))
      }

      inputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;
        var state = { service: {...this.state.service, [name]: value}};
        this.setState(state);
        this.props.inputChange(state.service);
      }

      
      render () {
        return (
        <div className="container">
          <div className="form-group">
            <div className="row">
                <div className="col-4">
                  <label className="col-form-label">Servicio
                    <Autocomplete 
                        inputProps={{className:"form-control" }}
                        wrapperStyle={{}}
                        value={this.state.service.Name}
                        items={this.state.serviceFiltered}
                        getItemValue={(item) => item.name}
                        onSelect={(value, item) => {
                            // set the menu to only the selected item
                            let state = { service: {...this.state.service, Name: value},
                                          serviceFiltered: [ item ] }
                            this.setState(state)                            
                            // or you could reset it to a default list again
                            //this.setState({ unitedStates: serviceFiltered(value) })
                            this.props.inputChange(state.service);                            
                        }}
                        onChange={(event, value) => {
                          let state = { service: {...this.state.service, Name: value},
                                        serviceFiltered: this.serviceFiltered(value) }
                          this.setState(state);
                          this.props.inputChange(state.service);                                          
                          //clearTimeout(this.requestTimer)
                          //this.requestTimer = fakeRequest(value, (items) => {
                          //  this.setState({ serviceList: items })
                          //})
                        }}
                        renderMenu={children => (
                          <div className="menu">
                            {children}
                          </div>
                        )}
                        renderItem={(item, isHighlighted) => (
                          <div
                            className={`item ${isHighlighted ? 'item-highlighted' : ''}`}
                            key={item.name}
                          >{item.name}</div>
                        )}                        
                    />
                  </label>
                </div>
              </div>    
          </div>
          <div className="form-group">
            <div className="row">
              <div className="col-4">
                <label className="col-form-label">Size
                  <input name="Size" type="number" className="form-control" value={this.state.service.Size} onChange={(event) => this.inputChange(event)} />
                </label>
              </div>
              <div className="col-4">
                <label className="float-left">Include Especial Char
                    <input name="IncludeEspecialChar" type="checkbox" className="form-control" disabled={this.state.service.OnlyNumbers} checked={this.state.service.IncludeEspecialChar} onChange={(event) => this.inputChange(event)} />
                </label>
              </div>
              <div className="col-4">
                <label className="float-left">Only Numbers
                  <input name="OnlyNumbers" type="checkbox" className="form-control"  checked={this.state.service.OnlyNumbers} onChange={(event) => this.inputChange(event)}  />
                </label>
              </div>
            </div>
            <div className="row">
              <div className="col-4"></div>    
              <div className="col-4">    
                <label className="float-left">Include Especial Char
                  <input name="IncludeEspecialChar" type="checkbox" className="form-control" disabled={this.state.service.OnlyNumbers} checked={this.state.service.IncludeEspecialChar} onChange={(event) => this.inputChange(event)} />
                </label>
              </div>  
            </div>
            <div className="row">
              <div className="col-4"></div>    
              <div className="col-4">    
                <label className="float-left">Include Upper Lower
                  <input name="IncludeUpperLower" type="checkbox" className="form-control" disabled={this.state.service.OnlyNumbers} checked={this.state.service.IncludeUpperLower} onChange={(event) => this.inputChange(event)} />
                </label>
              </div>  
            </div>
          </div>
        </div>);
      }
}