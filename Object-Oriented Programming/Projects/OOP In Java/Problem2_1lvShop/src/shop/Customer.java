package shop;

public class Customer {
	private String name;
	private int age;
	private double balance;	
	
	public Customer(String name, int age, double balance) {
		this.setName(name);
		this.setAge(age);
		this.setBalance(balance);
	}

	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		if (name.isEmpty() || name == null) {
			throw new IllegalArgumentException("Name is mandatory");
		}
		
		this.name = name;
	}
	
	public int getAge() {
		return age;
	}
	
	public void setAge(int age) {
		if (age < 0) {
			throw new IllegalArgumentException("Age can't be less than 0");
		}
		
		this.age = age;
	}
	
	public double getBalance() {		
		return balance;
	}
	
	public void setBalance(double balance) {
		this.balance = balance;
	}	
}