package shop.product;

import java.util.Date;

import interfaces.Expirable;

public class FoodProduct extends Product implements Expirable {
	private Date expirationDate;
	
	public FoodProduct(String name, double price, int quantity,
			AgeRestriction ageRestriction, Date expirationDate) {
		super(name, price, quantity, ageRestriction);
		this.setExpirationDate(expirationDate);
	}
	
	public void setExpirationDate(Date expirationDate) {
		this.expirationDate = expirationDate;
	}

	@Override
	public Date getExpirationDate() {
		return this.expirationDate;
	}
	
	@Override
	public double getPrice() {
		double price = this.price;
		Date date = new Date();
		int daysBetween = (int)
				((date.getTime() - this.getExpirationDate().getTime()) / (1000 * 60 * 60 * 24));    
		if (daysBetween < 15) {
			price *= 0.7;
		}
		
		return price;
	}
	
	@Override
	public String toString() {
		String output = super.toString();
		output += "Guarantee period in months: " + this.getExpirationDate().toString() + "\n";
		return output;
	}
}