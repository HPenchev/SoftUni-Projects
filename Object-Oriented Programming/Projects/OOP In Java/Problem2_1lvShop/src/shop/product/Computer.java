package shop.product;

public class Computer extends ElectronicsProduct {
	private final static int GUARANTEE_PERIOD_MONTHS = 24;
	
	public Computer(String name, double price, int quantity,
			AgeRestriction ageRestriction) {
		super(name, price, quantity, ageRestriction, GUARANTEE_PERIOD_MONTHS);		
	}
	
	@Override
	public double getPrice() {
		double price = this.price;
		if (this.getQuantity() > 1000) {
			price *= 0.95;
		}
		
		return price;
	}
}