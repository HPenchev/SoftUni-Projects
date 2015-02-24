package shop.product;

public class Appliance extends ElectronicsProduct {
	private static final int GUARANTEE_PERIOD_MONTHS = 6;
	
	public Appliance(String name, double price, int quantity,AgeRestriction ageRestriction) {
		super(name, price, quantity, ageRestriction, GUARANTEE_PERIOD_MONTHS);		
	}	
	
	@Override
	public double getPrice() {
		double price = this.price;
		if (this.getQuantity() < 50) {
			price *= 1.05;
		}
		
		return price;
	}
}
