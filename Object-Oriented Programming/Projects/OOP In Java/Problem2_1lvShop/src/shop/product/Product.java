package shop.product;

import interfaces.Buyable;

public abstract class Product implements Buyable {
	private String name;
	protected double price;
	private int quantity;
	private AgeRestriction ageRestriction;
	
	public Product(String name, double price, int quantity, AgeRestriction ageRestriction) {
		this.setName(name);
		this.setPrice(price);
		this.setQuantity(quantity);
		this.setAgeRestriction(ageRestriction);
	}
	
	public String getName() {
		return name;
	}

	public void setName(String name) {
		if (name.isEmpty() || name == null) {
			throw new IllegalArgumentException ("Product name can't be empty");
		}
		
		this.name = name;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		if (quantity < 0) {
			throw new IllegalArgumentException("Quantity can't be less than 0");
		}
		
		this.quantity = quantity;
	}

	public AgeRestriction getAgeRestriction() {
		return ageRestriction;
	}

	public void setAgeRestriction(AgeRestriction ageRestriction) {
		this.ageRestriction = ageRestriction;
	}

	public void setPrice(double price) {
		if(price < 0) {
			throw new IllegalArgumentException("Price can't be less than 0");
		}
		
		this.price = price;
	}

	@Override
	public double getPrice() {
		return this.price;
	}

	@Override
	public String toString() {
		String output = "Name: " + this.getName()+ "\n";
		output += "Price: " + this.getPrice() + "\n";
		output += "Quantity: " + this.getQuantity() + "\n";
		output += "Age restriction: " + this.getAgeRestriction().toString() + "\n";
		return output;
	}
}