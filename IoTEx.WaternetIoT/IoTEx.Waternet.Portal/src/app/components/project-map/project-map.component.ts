import { Component, OnInit, Input,OnChanges,SimpleChanges ,ViewChild, ElementRef,AfterViewInit,Renderer2  } from '@angular/core';
import * as atlas from 'azure-maps-control';
import { environment } from 'src/app/environments/environment';
import { Observable, Subject } from 'rxjs';
import { IoTExService } from '../../services/_index';
import * as DTO from '../../models/_index';
import { BaseComponent } from '../../base.component';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-project-map',
  templateUrl: './project-map.component.html',
  styleUrl: './project-map.component.css'
})
export class ProjectMapComponent implements OnChanges, OnInit ,AfterViewInit  {
  
  map!: atlas.Map;
  public message: string = '';
  public uniqueId: string = '';
  @Input() mapContainerId!: string; 
  @Input() latitude!: number;
  @Input() longitude!: number;
  @Input() assetUID!: string;
  @Input() device!: DTO.DeviceDTO;
  @Input() data!: DTO.Device2ProjectDTO[];
  constructor(private renderer: Renderer2) {
    this.uniqueId=uuidv4();
  }
  ngAfterViewInit () {
    if (this.assetUID != undefined){
      this.showDevice(this.latitude, this.longitude, this.assetUID);
    }
    else if (this.device != undefined) {
      console.log("showDevice",this.device  );
      this.showDevice(this.device.lat, this.device.long, this.device.assetUID);
    }
  }
  ngOnInit(): void {
    
    
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['data']) {
      console.log("showdata");
      this.showAlDevices()
    }
  }
  showAlDevices() {
    this.message='';
    if (this.data == undefined) {
      return;
    }
    if (this.data.length == 0) {
      return;
    }
    const totalLatScore = this.data.reduce((sum, device) => sum + device.deviceLat, 0);
    const lat = totalLatScore / this.data.length;

    const totalLongScore = this.data.reduce((sum, device) => sum + device.deviceLong, 0);
    const long = totalLongScore / this.data.length;

    console.log("showAlDevices",this.data);
    this.map = new atlas.Map('map-'+this.uniqueId, {
      center: [long,lat], // Set the center coordinates
      zoom: 12, // Set the zoom level
      authOptions: {
        authType: atlas.AuthenticationType.subscriptionKey,
        subscriptionKey: environment.mapSubscriptionKey
      }
    });
    this.map.events.add('ready', () => {
      // Add controls to the map
      this.map.controls.add(new atlas.control.ZoomControl(), {
        position: atlas.ControlPosition.TopRight
      });

      let southwestLongitude=240;
      let southwestLatitude=240;
      let northeastLongitude=-240;
      let northeastLatitude=-240;

      const dataSource = new atlas.source.DataSource();
      this.map.sources.add(dataSource);

      for (let i = 0; i < this.data.length; i++) {
        southwestLatitude = (this.data[i].deviceLat < southwestLatitude) ? this.data[i].deviceLat: southwestLatitude;
        southwestLongitude = (this.data[i].deviceLong < southwestLongitude) ? this.data[i].deviceLong: southwestLongitude;
        northeastLatitude = (this.data[i].deviceLat > northeastLatitude) ? this.data[i].deviceLat: northeastLatitude;
        northeastLongitude = (this.data[i].deviceLong > northeastLongitude) ? this.data[i].deviceLong: northeastLongitude;
        dataSource.add(new atlas.data.Feature(
                new atlas.data.Point([this.data[i].deviceLong, this.data[i].deviceLat]),{name:this.data[i].assetUID}));
      }
      const symbolLayer = new atlas.layer.SymbolLayer(dataSource, null, {
        iconOptions: {
            image: 'pin-round-darkblue', // Built-in Azure Maps icon or custom image
            anchor: 'center', // Center the icon on the coordinates
            allowOverlap: true, // Allow overlapping pins
            size: 1 // Resize the icon if needed
        },
        textOptions: {
          textField: ['get', 'name'], // Get the 'name' property from the data point
          allowOverlap: true,
          offset: [0, 1.2], // Offset the text above the point
          color: '#000000', // Text color
          size: 14, // Font size
          anchor: 'top' // Text alignment relative to the point
      }
      });        
        // Add the symbol layer to the map
      this.map.layers.add(symbolLayer);

      console.log("bounds",southwestLatitude,southwestLongitude,northeastLatitude,northeastLongitude);
      this.map.setCamera({
        bounds: [southwestLongitude, southwestLatitude, northeastLongitude, northeastLatitude],
        padding: 50, // Optional padding around the edges
      });
    });

    // Add a sample point/marker to the map
    
  }
  showDevice(lat,long, name) {
    
    
    this.message='';
    console.log("showDevice",lat,long,name);
    if (lat == 0 || long == 0) {
      this.message = "No location data available for this device";
      return;
    }
    
    // Initialize the map
    const mapElement = document.getElementById('map-'+this.uniqueId);
    //console.log("Initialize the map",mapElement);
    this.map = new atlas.Map('map-'+this.uniqueId, {
      center: [long,lat], // Set the center coordinates
      zoom: 12, // Set the zoom level
      authOptions: {
        authType: atlas.AuthenticationType.subscriptionKey,
        subscriptionKey: environment.mapSubscriptionKey
      }
    });

    // Add event listener for map ready event
    this.map.events.add('ready', () => {
      // Add controls to the map
      this.map.controls.add(new atlas.control.ZoomControl(), {
        position: atlas.ControlPosition.TopRight
      });

      const dataSource = new atlas.source.DataSource();
      this.map.sources.add(dataSource);
      dataSource.add(new atlas.data.Feature(
        new atlas.data.Point([long, lat]),{name:name}));

      const symbolLayer = new atlas.layer.SymbolLayer(dataSource, null, {
      iconOptions: {
          image: 'pin-round-darkblue', // Built-in Azure Maps icon or custom image
          anchor: 'center', // Center the icon on the coordinates
          allowOverlap: true, // Allow overlapping pins
          size: 1 // Resize the icon if needed
      },
        textOptions: {
          textField: ['get', 'name'], // Get the 'name' property from the data point
          allowOverlap: true,
          offset: [0, 1.2], // Offset the text above the point
          color: '#000000', // Text color
          size: 14, // Font size
          anchor: 'top' // Text alignment relative to the point
      }
      });        
          // Add the symbol layer to the map
      this.map.layers.add(symbolLayer);
  

    });
  }
  
}
