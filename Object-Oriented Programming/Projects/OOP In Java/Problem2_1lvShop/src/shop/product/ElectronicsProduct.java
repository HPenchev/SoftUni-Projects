package shop.product;

public abstract class ElectronicsProduct extends Product {
	private int guaranteePeriodMonths;
	
	public ElectronicsProduct(String name, double price, int quantity,
			AgeRestriction ageRestriction, int guaranteePeriodMonths) {
		super(name, price, quantity, ageRestriction);
		this.setGuaranteePeriodMonths(guaranteePeriodMonths);
	}

	public int getGuaranteePeriodMonths() {
		return guaranteePeriodMonths;
	}

	public void setGuaranteePeriodMonths(int guaranteePeriodMonths) {
		if (guaranteePeriodMonths < 0) {
			throw new IllegalArgumentException ("Guarantee period can't be less than 0");
		}
		
		this.guaranteePeriodMonths = guaranteePeriodMonths;
	}

	@Override
	public String toString() {
		String output = super.toString();
		output += "Guarantee period in months: " + this.getGuaranteePeriodMonths() + "\n";
		return output;
	}		
}
