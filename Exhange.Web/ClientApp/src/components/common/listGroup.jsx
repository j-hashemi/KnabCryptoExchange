import React from 'react';
const ListGroup = (props) => {

    const listItemClass = "list-group-item list-group-item-action";
    const {items, onSelectItem, currentSelectItem} = props;

    return (<ul className="list-group list-group-flush">
        {items.map(item => (
            <li key={item.id} 
                className={currentSelectItem &&  item.id==currentSelectItem.id?  listItemClass+" active": listItemClass} 
                onClick={()=>onSelectItem(item)}>
                  {item.name}({item.symbol})
            </li>
        ))}
</ul>);
}
 
export default ListGroup;