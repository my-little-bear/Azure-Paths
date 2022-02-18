import React from "react";

const Pet = ({
  name,
  animal,
  breed,
  location,
  images,
  id
}) => {

  let hero = 'http://pets-images.dev-apis.com/pets/none.jpg';
  if(images.length){
    hero = images[0]
  }
  return (
    <div>
      <a href={`/details/${id}`} className="pet">
      <div className="image-container">
        <img src={hero} alt={name}/>
      </div>
      <div className="info">
        <h1>{name}</h1>
        <h2>{`${animal} - ${breed} - ${location}`}</h2>
      </div>
    </a>
    </div>
  );
};

export default Pet;