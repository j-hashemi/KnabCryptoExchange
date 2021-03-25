import React from 'react';
import CurrencyInput from 'react-currency-input-field';

const CurrencyInputGroup = (props) => {
    const {onValueChange,symbol} = props; 
    return ( <div className="input-group mb-3">
    <CurrencyInput
    id="input-example"
    name="input-name"
    placeholder="Please enter a number"
    defaultValue={1}
    decimalsLimit={2}
    className="form-control"
    onValueChange={onValueChange}/>
        <div className="input-group-append"><span className="input-group-text">{symbol}</span></div>
    </div>  );
}
 
export default CurrencyInputGroup;