/*
 * - CONSIDER using records over classes
 *     Unless:
 *     - Inheritance chains with classes are required
 *     - The identity of the object is not based of the value of all its fields
 * - AVOID positional records when validation of positional members is required
 * - CONSIDER using init properties instead of readonly properties for optional values
 * - DO define a constructor to allow setting init properties for backwards compatibility with pre-C# 9
 * - DO name record positional parameter with PascalCase
*/
