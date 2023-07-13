package ecom.catalog.CatalogService;

import java.util.List;
import java.util.UUID;

import org.springframework.data.jpa.repository.JpaRepository;

import ecom.catalog.CatalogService.POJO.Product;

public interface ProductRepository extends JpaRepository<Product, UUID> {
    List<Product> findByNameContainingOrDescriptionContainingAllIgnoreCase(String name, String description);
}
