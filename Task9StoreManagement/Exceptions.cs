namespace Task9StoreManagement;

public class InvalidQuantityException(string message) : Exception(message) { }

public class ProductNotFoundException(string message) : Exception(message) { }

public class InvalidPriceException(string message) : Exception(message) { }