import { Product } from "../../app/models/product"

type Props = {
  products: Product[];
  addProduct: () => void;
}

export default function Catalog({products, addProduct}: Props) {
  return (
    <>
      <ul>
        {products.map((item, index) => (
          <li key={index}> {item.name} - {item.price} -  {item.description}</li>
        ))}
      </ul>
      <button onClick={addProduct}>Add Product</button>

    </>
  )
}